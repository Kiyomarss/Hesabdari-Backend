using ServiceContracts;
using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.ConsultationRequest;
using Hesabdari_Core.Utils;
using RepositoryContracts;

namespace Services
{
    public class ConsultationRequestsGetterService : IConsultationRequestsGetterService
    {
        private readonly IConsultationRequestsRepository _consultationRequestsRepository;

        public ConsultationRequestsGetterService(IConsultationRequestsRepository consultationRequestsRepository)
        {
            _consultationRequestsRepository = consultationRequestsRepository;
        }

        public virtual async Task<ItemsResult<ConsultationRequestResultDto>> GetConsultationRequests()
        {
            var list = await _consultationRequestsRepository.GetConsultationRequests();

            var resultDtos = list
                       .Select(x => new ConsultationRequestResultDto(
                                                                     x.Id,
                                                                     x.FullName,
                                                                     x.CompanyName,
                                                                     x.Email,
                                                                     x.PhoneNumber,
                                                                     x.Description,
                                                                     x.ServiceType,
                                                                     x.IsStarred,
                                                                     x.IsRead,
                                                                     ((DateTime?)x.CreateAt).ToPersianDate()
                                                                    ))
                       .ToList();

            return new ItemsResult<ConsultationRequestResultDto>(resultDtos);
        }

        public virtual async Task<ItemsResult<ConsultationRequestResultDto>> GetStarredConsultationRequests()
        {
            var list = await _consultationRequestsRepository.GetStarredConsultationRequests();

            var resultDtos = list
                       .Select(x => new ConsultationRequestResultDto(
                                                                     x.Id,
                                                                     x.FullName,
                                                                     x.CompanyName,
                                                                     x.Email,
                                                                     x.PhoneNumber,
                                                                     x.Description,
                                                                     x.ServiceType,
                                                                     x.IsStarred,
                                                                     x.IsRead,
                                                                     ((DateTime?)x.CreateAt).ToPersianDate()
                                                                    ))
                       .ToList();

            return new ItemsResult<ConsultationRequestResultDto>(resultDtos);
        }

        public virtual async Task<ItemResult<int>> GetUnreadCount()
        {
            var count = await _consultationRequestsRepository.GetUnreadCount();
            return new ItemResult<int>(count); 
        }
    }
}