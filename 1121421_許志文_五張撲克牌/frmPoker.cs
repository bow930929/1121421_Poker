using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1121421_許志文_五張撲克牌  // ← 換成你的 namespace
{
    public partial class frmPoker : Form
    {
        PictureBox[] pic = new PictureBox[5];
        int[] allPoker = new int[52];
        int[] playerPoker = new int[5];

        int totalMoney = 0;
        int betAmount = 0;
        bool betPlaced = false;

        public frmPoker()
        {
            InitializeComponent();
            InitializePoker();

            txtMoney.ReadOnly = false;
            txtMoney.Text = "";
            txtBet.Enabled = false;   
            btnBet.Enabled = false;
            btnDealCard.Enabled = false;
            btnChangeCard.Enabled = false;
            btnCheck.Enabled = false;
            lblResult.Text = "請在「總資金」欄位輸入金額後按 Enter 開始遊戲";
        }

        // ──────────────────────────────────────
        //  Form Load：鎖定全部按鈕，等待輸入資金
        // ──────────────────────────────────────
        private void frmPoker_Load(object sender, EventArgs e)
        {
            txtMoney.ReadOnly = false;
            txtMoney.Text = "";
            btnBet.Enabled = false;
            btnDealCard.Enabled = false;
            btnChangeCard.Enabled = false;
            btnCheck.Enabled = false;
            lblResult.Text = "請在「總資金」欄位輸入金額後按 Enter 開始遊戲";
        }

        // ──────────────────────────────────────
        //  txtMoney KeyPress：按 Enter 確認資金
        // ──────────────────────────────────────
        private void txtMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (int.TryParse(txtMoney.Text, out int amount) && amount > 0)
                {
                    totalMoney = amount;
                    txtMoney.ReadOnly = true;
                    txtBet.Enabled = true;   // ← 解鎖 txtBet
                    txtBet.Focus();             // ← 游標移到 txtBet
                    lblResult.Text = "請輸入押注金額後按 Enter 押注";
                }
                else
                {
                    MessageBox.Show("請輸入有效的金額（正整數）！", "錯誤");
                    txtMoney.Text = "";
                }
                e.Handled = true;
            }
        }

        // ──────────────────────────────────────
        //  初始化五張牌（置中）
        // ──────────────────────────────────────
        private void InitializePoker()
        {
            int spacing = 10;

            for (int i = 0; i < 5; i++)
            {
                pic[i] = new PictureBox();
                pic[i].Image = GetImage("back");
                pic[i].Name = "pic" + i;
                pic[i].SizeMode = PictureBoxSizeMode.AutoSize;
                pic[i].Visible = true;
                pic[i].Enabled = false;
                pic[i].Tag = "back";
                this.grpPoker.Controls.Add(pic[i]);
                pic[i].MouseClick += new MouseEventHandler(pic_Click);
            }

            // 計算置中位置（加入 Controls 後才能取得 Width）
            int cardWidth = pic[0].Width;
            int cardHeight = pic[0].Height;
            int totalWidth = 5 * cardWidth + 4 * spacing;
            int startLeft = (grpPoker.ClientSize.Width - totalWidth) / 2;
            int startTop = (grpPoker.ClientSize.Height - cardHeight) / 2;

            for (int i = 0; i < 5; i++)
            {
                pic[i].Left = startLeft + i * (cardWidth + spacing);
                pic[i].Top = startTop;
            }
        }

        // ──────────────────────────────────────
        //  取得圖片資源
        // ──────────────────────────────────────
        private Image GetImage(string name)
        {
            return _1121421_許志文_五張撲克牌.Properties.Resources.ResourceManager
                        .GetObject(name) as Image;  // ← namespace 同上
        }

        // ──────────────────────────────────────
        //  押注
        // ──────────────────────────────────────
        private void btnBet_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBet.Text, out int amount) || amount <= 0)
            {
                MessageBox.Show("請輸入有效的押注金額！", "錯誤");
                return;
            }
            if (amount > totalMoney)
            {
                MessageBox.Show("押注金額不能超過總資金！", "錯誤");
                return;
            }

            betAmount = amount;
            betPlaced = true;
            btnDealCard.Enabled = true;
            btnBet.Enabled = false;
            txtBet.Enabled = false;

            // ↓ 加這段：蓋牌
            for (int i = 0; i < 5; i++)
            {
                pic[i].Image = GetImage("back");
                pic[i].Tag = "back";
                pic[i].Enabled = false;
            }

            lblResult.Text = $"已押注 {betAmount} 元，請按「發牌」";
        }

        // ──────────────────────────────────────
        //  發牌
        // ──────────────────────────────────────
        private async void btnDealCard_Click(object sender, EventArgs e)
        {
            if (!betPlaced) { MessageBox.Show("請先押注！"); return; }

            for (int i = 0; i < 5; i++)
                pic[i].Image = GetImage("back");

            for (int i = 0; i < 52; i++) allPoker[i] = i;
            Shuffle();

            await Task.Delay(500);

            for (int i = 0; i < 5; i++)
            {
                playerPoker[i] = allPoker[i];
                pic[i].Image = GetImage("pic" + (playerPoker[i] + 1));
                pic[i].Tag = "front";
                pic[i].Enabled = true;
            }

            lblResult.Text = "點選要換的牌（蓋牌），再按「換牌」，" +
                "若無則直接按「換牌」即可";
            btnDealCard.Enabled = false;
            btnChangeCard.Enabled = true;
            btnCheck.Enabled = false;
        }

        // ──────────────────────────────────────
        //  洗牌
        // ──────────────────────────────────────
        private void Shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < allPoker.Length; i++)
            {
                int r = rand.Next(allPoker.Length);
                int temp = allPoker[r];
                allPoker[r] = allPoker[i];
                allPoker[i] = temp;
            }
        }

        // ──────────────────────────────────────
        //  點擊撲克牌（選/取消要換的牌）
        // ──────────────────────────────────────
        private void pic_Click(object sender, MouseEventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            int index = int.Parse(p.Name.Replace("pic", ""));

            if (p.Tag.ToString() == "front")
            {
                p.Tag = "back";
                p.Image = GetImage("back");
            }
            else
            {
                p.Tag = "front";
                p.Image = GetImage("pic" + (playerPoker[index] + 1));
            }
        }

        // ──────────────────────────────────────
        //  換牌
        // ──────────────────────────────────────
        private void btnChangeCard_Click(object sender, EventArgs e)
        {
            int cardIndex = 5;
            for (int i = 0; i < pic.Length; i++)
            {
                if (pic[i].Tag.ToString() == "back")
                {
                    playerPoker[i] = allPoker[cardIndex++];
                    pic[i].Image = GetImage("pic" + (playerPoker[i] + 1));
                    pic[i].Tag = "front";
                }
            }

            for (int i = 0; i < pic.Length; i++)
                pic[i].Enabled = false;

            btnChangeCard.Enabled = false;
            btnCheck.Enabled = true;
            lblResult.Text = "換牌完成，請按「判斷牌型」";
        }

        // ──────────────────────────────────────
        //  判斷牌型
        // ──────────────────────────────────────
        private void btnCheck_Click(object sender, EventArgs e)
        {
            GetHandResult(out string handName, out int multiplier);

            int winAmount = betAmount * multiplier;
            int netChange = winAmount - betAmount;   // 實際盈虧
            totalMoney += netChange;
            txtMoney.Text = totalMoney.ToString();

            if (multiplier == 0)
                lblResult.Text = $"{handName}　輸掉 {betAmount} 元　剩餘：{totalMoney} 元";
            else if (netChange == 0)
                lblResult.Text = $"{handName}（賠率 {multiplier}x）　平手　剩餘：{totalMoney} 元";
            else
                lblResult.Text = $"{handName}（賠率 {multiplier}x）　贏得 {netChange} 元　剩餘：{totalMoney} 元";

            if (totalMoney <= 0)
            {
                MessageBox.Show("資金歸零，遊戲結束！", "Game Over");
                btnBet.Enabled = false;
                txtBet.Enabled = false;
                btnCheck.Enabled = false;
                return;
            }

            // 重置，準備下一局
            betPlaced = false;
            btnCheck.Enabled = false;
            btnChangeCard.Enabled = false;
            btnBet.Enabled = true;
            txtBet.Enabled = true;
        }

        // ──────────────────────────────────────
        //  牌型判斷邏輯
        // ──────────────────────────────────────
        private void GetHandResult(out string handName, out int multiplier)
        {
            string[] colorList = { "梅花", "方塊", "愛心", "黑桃" };
            string[] pointList = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

            int[] pokerColor = new int[5];
            int[] pokerPoint = new int[5];
            for (int i = 0; i < 5; i++)
            {
                pokerColor[i] = playerPoker[i] % 4;
                pokerPoint[i] = playerPoker[i] / 4;
            }

            int[] colorCount = new int[4];
            int[] pointCount = new int[13];
            for (int i = 0; i < 5; i++)
            {
                colorCount[pokerColor[i]]++;
                pointCount[pokerPoint[i]]++;
            }

            Array.Sort(colorCount, colorList); Array.Reverse(colorCount); Array.Reverse(colorList);
            Array.Sort(pointCount, pointList); Array.Reverse(pointCount); Array.Reverse(pointList);

            bool isFlush = colorCount[0] == 5;
            bool isSingle = pointCount[0] == 1;
            bool isDiffFour = pokerPoint.Max() - pokerPoint.Min() == 4;
            bool isRoyal = pokerPoint.Contains(0) && pokerPoint.Contains(9)
                                && pokerPoint.Contains(10) && pokerPoint.Contains(11)
                                && pokerPoint.Contains(12);

            bool isRoyalFlush = isFlush && isRoyal;
            bool isStraightFlush = isFlush && isSingle && isDiffFour;
            bool isStraight = isSingle && (isDiffFour || isRoyal);
            bool isFourOfAKind = pointCount[0] == 4;
            bool isFullHouse = pointCount[0] == 3 && pointCount[1] == 2;
            bool isThreeOfAKind = pointCount[0] == 3 && pointCount[1] == 1;
            bool isTwoPair = pointCount[0] == 2 && pointCount[1] == 2;
            bool isOnePair = pointCount[0] == 2 && pointCount[1] == 1;

            if (isRoyalFlush) { handName = $"{colorList[0]} 皇家同花順"; multiplier = 250; }
            else if (isStraightFlush) { handName = $"{colorList[0]} 同花順"; multiplier = 50; }
            else if (isFourOfAKind) { handName = $"{pointList[0]} 四條"; multiplier = 25; }
            else if (isFullHouse) { handName = $"{pointList[0]}三帶{pointList[1]}二 葫蘆"; multiplier = 9; }
            else if (isFlush) { handName = $"{colorList[0]} 同花"; multiplier = 6; }
            else if (isStraight) { handName = "順子"; multiplier = 4; }
            else if (isThreeOfAKind) { handName = $"{pointList[0]} 三條"; multiplier = 3; }
            else if (isTwoPair) { handName = $"{pointList[0]},{pointList[1]} 兩對"; multiplier = 2; }
            else if (isOnePair) { handName = $"{pointList[0]} 一對"; multiplier = 1; }
            else { handName = "雜牌"; multiplier = 0; }
        }

        // ──────────────────────────────────────
        //  顯示五張牌（秘技用）
        // ──────────────────────────────────────
        private void ShowCards()
        {
            for (int i = 0; i < 5; i++)
                pic[i].Image = GetImage($"pic{playerPoker[i] + 1}");
        }

        // ──────────────────────────────────────
        //  KeyPress 秘技
        // ──────────────────────────────────────
        private void frmPoker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (btnDealCard.Enabled) return;

            switch ((int)e.KeyChar)
            {
                case 113: playerPoker = new[] { 51, 47, 43, 39, 3 }; break; // q 皇家同花順
                case 119: playerPoker = new[] { 37, 33, 29, 25, 21 }; break; // w 同花順
                case 101: playerPoker = new[] { 50, 38, 34, 22, 18 }; break; // e 同花
                case 114: playerPoker = new[] { 48, 39, 38, 37, 36 }; break; // r 四條
                case 116: playerPoker = new[] { 30, 29, 6, 5, 4 }; break; // t 葫蘆
                case 121: playerPoker = new[] { 48, 39, 15, 14, 13 }; break; // y 三條
                default: return;
            }
            ShowCards();
        }

        private void txtMoney_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBet_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 只允許數字
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBet_Click(sender, e);   // ← 直接呼叫押注邏輯
                e.Handled = true;
            }
        }
    }
}