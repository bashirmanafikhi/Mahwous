using AutoMapper;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Identity;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.Messages
{
    public class SearchMessagesHandler : IRequestHandler<SearchMessagesQuery, SearchMessagesResponse>
    {
        private readonly IMessageRepository messageRepository;
        private readonly IMapper mapper;
        private readonly IUserService userService;
        private readonly IReportRepository reportRepository;

        public SearchMessagesHandler(IMessageRepository messageRepository, IMapper mapper, IUserService userService, IReportRepository reportRepository)
        {
            this.messageRepository = messageRepository;
            this.mapper = mapper;
            this.userService = userService;
            this.reportRepository = reportRepository;
        }

        public async Task<SearchMessagesResponse> Handle(SearchMessagesQuery request, CancellationToken cancellationToken)
        {
            // get current user
            var user = await userService.GetCurrentUser();

            var filter = mapper.Map<MessageFilter>(request.Filter);
            if (user?.Id != null)
            {
                // get all related violators
                var reportFilter = new ReportFilter();
                reportFilter.UserId = user.Id;
                var reports = await reportRepository.ListAllAsync();
                var violatorIds = reports.Select(r => r.ViolatorId).Distinct().ToList();

                // exlude violator's messages
                filter.Predicate = x => !violatorIds.Contains(x.UserId);
            }


            // get the messages
            var messages = await messageRepository.SearchAsync(filter, request.Pagination, request.SortType);

            // reverse them to start reading from the last message added
            messages.Items = messages.Items.Reverse();

            // map the messages
            var response = mapper.Map<SearchMessagesResponse>(messages);

            // setup response
            foreach (var message in response.Items)
            {
                message.IsOwner = message.UserId == user.Id;
            }

            return response;
        }
    }
}
