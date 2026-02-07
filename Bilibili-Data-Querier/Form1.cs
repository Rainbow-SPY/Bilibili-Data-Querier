using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UAPI;
using static Rox.Runtimes.LocalizedString;
using static Rox.Runtimes.LogLibraries;

namespace Bilibili_Data_Querier
{
    public partial class Form1 : AntdUI.Window
    {
        public SearchType _SearchType;
        public bilibili.ArchiveType _ArchiveType;
        public bilibili.UserType _UserType;
        public bilibili.VideoType _VideoType;
        public bilibili.LiveRoomType _LiveRoomType;
        // 预编译正则表达式（提升性能）
        private static readonly Regex _videoRegex = new Regex(@"(?:https?://)?www\.bilibili\.com/video/((?:BV|AV)[a-zA-Z0-9]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex _userRegex = new Regex(@"(?:https?://)?space\.bilibili\.com/(\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex _liveRegex = new Regex(@"(?:https?://)?live\.bilibili\.com/(\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public Form1()
        {
            InitializeComponent();
        }

        public async Task GetResult()
        {
            switch (_SearchType)
            {
                case SearchType.LiveRoomID:
                    await GetFromLiveRoom();
                    break;
                case SearchType.AVID:
                    await GetFromVideo(bilibili.BiliVideoIDType.AID);
                    break;
                case SearchType.BVID:
                    await GetFromVideo(bilibili.BiliVideoIDType.BVID);
                    break;
                case SearchType.UID:
                    await GetFromUID();
                    break;
                default:
                    return;
            }
        }
        public async Task GetFromLiveRoom(string id)
        {
            _LiveRoomType = await bilibili.GetLiveRoomStatus.AsLiveroomID(id);
            var uid = _LiveRoomType?.uid;
            _UserType = await bilibili.GetUserData(uid?.ToString());
            _ArchiveType = await bilibili.GetArchives(uid?.ToString());
        }
        public async Task GetFromUID(string id)
        {
            _UserType = await bilibili.GetUserData(id);
            _ArchiveType = await bilibili.GetArchives(id);
            _LiveRoomType = await bilibili.GetLiveRoomStatus.AsID(id);
            WriteLog.Info($"直播状态: {(_LiveRoomType.live_status == 0 ? "未开播" : (_LiveRoomType.live_status == 1 ? "直播中" : "轮播中"))}");
        }
        /// <summary>
        /// 分析B站URL，返回对应的类型枚举
        /// </summary>
        /// <param name="url">B站URL</param>
        /// <returns>对应的SearchType枚举</returns>
        public static SearchType AnalyzeBilibiliUrl(string url)
        {
            // 空值/空白值直接返回未知
            if (string.IsNullOrWhiteSpace(url))
                return SearchType.Unknown;

            // 优先匹配视频链接（BV/AV）
            var videoMatch = _videoRegex.Match(url);
            if (videoMatch.Success)
            {
                string videoId = videoMatch.Groups[1].Value.ToUpper();
                // 判断是BV还是AV开头
                return videoId.StartsWith("BV") ? SearchType.BVID : SearchType.AVID;
            }

            // 匹配用户空间链接
            if (_userRegex.IsMatch(url))
                return SearchType.UID;

            // 匹配直播间链接
            if (_liveRegex.IsMatch(url))
                return SearchType.LiveRoomID;

            // 都不匹配返回未知
            return SearchType.Unknown;
        }
        /// <summary>
        /// 提取B站URL中的具体ID值
        /// </summary>
        /// <param name="url">B站URL</param>
        /// <returns>提取到的ID（失败返回null）</returns>
        public static string ExtractBilibiliId(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return null;

            // 提取视频ID（BV/AV）
            var videoMatch = _videoRegex.Match(url);
            if (videoMatch.Success)
                return videoMatch.Groups[1].Value;

            // 提取UID
            var userMatch = _userRegex.Match(url);
            if (userMatch.Success)
                return userMatch.Groups[1].Value;

            // 提取直播间ID
            var liveMatch = _liveRegex.Match(url);
            if (liveMatch.Success)
                return liveMatch.Groups[1].Value;

            // 无匹配返回null
            return null;
        }

        /// <summary>
        /// 一次性获取URL类型和对应的ID（推荐使用，减少正则匹配次数）
        /// </summary>
        /// <param name="url">B站URL</param>
        /// <returns>元组：(类型枚举, 提取的ID)</returns>
        public static (SearchType Type, string Id) GetBilibiliUrlInfo(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return (SearchType.Unknown, null);

            // 匹配视频链接（BV/AV）
            var videoMatch = _videoRegex.Match(url);
            if (videoMatch.Success)
            {
                string id = videoMatch.Groups[1].Value;
                SearchType type = id.ToUpper().StartsWith("BV") ? SearchType.BVID : SearchType.AVID;
                return (type, id);
            }

            // 匹配用户空间链接
            var userMatch = _userRegex.Match(url);
            if (userMatch.Success)
                return (SearchType.UID, userMatch.Groups[1].Value);

            // 匹配直播间链接
            var liveMatch = _liveRegex.Match(url);
            if (liveMatch.Success)
                return (SearchType.LiveRoomID, liveMatch.Groups[1].Value);

            return (SearchType.Unknown, null);
        }
        public async Task GetFromVideo(string id, bilibili.BiliVideoIDType type)
        {
            _VideoType = await bilibili.GetVideoData(id, type);
            var uid = _VideoType.owner.mid.ToString();
            _UserType = await bilibili.GetUserData(uid);
            _ArchiveType = await bilibili.GetArchives(uid);
            _LiveRoomType = await bilibili.GetLiveRoomStatus.AsID(uid);
        }
        public enum SearchType
        {
            Unknown,

            LiveRoomID,

            UID,

            BVID,

            AVID,
        }
        private async Task button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(IInput.Text))
            {
                WriteLog.Error("请输入查询内容");
                MessageBox_I.Error("请输入查询内容", _ERROR);
                return;
            }
            else
            {
                if (dropdown1.SelectedValue == null)
                {
                    WriteLog.Error("请选择查询的类型");
                    MessageBox_I.Error("请选择查询的类型", _ERROR);
                }
            }
            if (!(IInput.Text.StartsWith("av") && IInput.Text.StartsWith("bv")))
            {

            }
            var (a, id) = GetBilibiliUrlInfo(IInput.Text);
            switch (a)
            {
                case SearchType.LiveRoomID:
                    await GetFromLiveRoom(id);
                    break;
                case SearchType.UID:
                    await GetFromUID(id);
                    break;
                case SearchType.AVID:
                    await GetFromVideo(id, bilibili.BiliVideoIDType.AID);
                    break;
                case SearchType.BVID:
                    await GetFromVideo(id, bilibili.BiliVideoIDType.BVID);
                    break;
            }
        }
        private void ClearData()
        {
            _LiveRoomType = null;
            _UserType = null;
            _ArchiveType = null;
            _VideoType = null;

        }
        private void dropdown1_SelectedValueChanged(object sender, AntdUI.ObjectNEventArgs e)
        {
            switch (dropdown1.SelectedValue)
            {
                case "用户UID":
                    _SearchType = SearchType.UID;
                    break;
                case "直播间ID":
                    _SearchType = SearchType.LiveRoomID;
                    break;
                case "视频BV号":
                    _SearchType = SearchType.BVID;
                    break;
                case "视频AV号":
                    _SearchType = SearchType.AVID;
                    break;
            }
            dropdown1.Text = dropdown1.SelectedValue.ToString();
            WriteLog.Debug($"选择了属性:{dropdown1.SelectedValue}");
        }
    }
}
