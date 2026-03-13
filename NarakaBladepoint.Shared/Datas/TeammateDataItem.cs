using Avalonia.Media;
using NarakaBladepoint.Resources;

namespace NarakaBladepoint.Shared.Datas
{
    public class TeammateDataItem
    {
        private int _avatarIndex;

        /// <summary>
        /// 澶村儚绱㈠紩
        /// </summary>
        public int AvatarIndex
        {
            get { return _avatarIndex; }
            set
            {
                _avatarIndex = value;
                // 纭繚绱㈠紩鍦ㄦ湁鏁堣寖鍥村唴
                if (_avatarIndex < 0 || _avatarIndex >= ResourceImageReader.AvatarCount)
                {
                    _avatarIndex = 0;
                }
            }
        }

        /// <summary>
        /// 澶村儚
        /// </summary>
        public IImage Avatar => ResourceImageReader.GetSocialAvatarImage(AvatarIndex);

        /// <summary>
        /// 鍚嶅瓧
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 鎻忚堪/鑱屼笟
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 鏍囩鍒楄〃
        /// </summary>
        public List<string> Tags { get; set; } = new();
    }
}
