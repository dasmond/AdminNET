using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furion.Extras.Admin.NET.Service.Notice
{
    public interface ISysNoticeService
    {
        Task AddNotice(AddNoticeInput input);

        Task ChangeStatus(ChangeStatusNoticeInput input);

        Task DeleteNotice(DeleteNoticeInput input);

        Task<NoticeDetailOutput> GetNotice([FromQuery] QueryNoticeInput input);

        Task<PageResult<SysNotice>> QueryNoticePageList([FromQuery] NoticePageInput input);

        Task<PageResult<NoticeReceiveOutput>> ReceivedNoticePageList([FromQuery] NoticePageInput input);

        Task UpdateNotice(UpdateNoticeInput input);
    }
}