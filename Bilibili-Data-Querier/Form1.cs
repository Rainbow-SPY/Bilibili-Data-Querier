using System;
using System.Threading.Tasks;
using UAPI;

namespace Bilibili_Data_Querier
{
    public partial class Form1 : AntdUI.Window
    {
        public Form1()
        {
            InitializeComponent();
            SearchType _Type = (IInput.Text == "用户UID" ? Form1.SearchType.UID : Form1.SearchType.LiveRoomID);

        }

        public async Task GetResult()
        {
            var a = await bilibili.GetArchives(IInput.Text);
            var b = await bilibili.GetUserData(IInput.Text);
            var c = await bilibili.GetLiveRoomStatus.AsID(IInput.Text);
            var d = await bilibili.GetVideoData("bv2e", bilibili.BiliVideoIDType.BVID);


        }
        public enum SearchType
        {
            LiveRoomID,

            UID
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
