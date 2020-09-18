using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using MahwousVideos.ViewModels;
using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using Xamarin.Forms;

namespace MahwousPosts.ViewModels
{

    public class PostsViewModel : BaseViewModel
    {
        PaginationDTO paginationDTO = new PaginationDTO();
        private int totalAmountPages;


        bool isLoadingMore = false;
        public bool IsLoadingMore
        {
            get { return isLoadingMore; }
            set { SetProperty(ref isLoadingMore, value); }
        }

        private int itemTreshold = 3;
        public int ItemTreshold
        {
            get { return itemTreshold; }
            set { SetProperty(ref itemTreshold, value); }
        }

        public event EventHandler PostsFinished;

        public ObservableCollection<Post> Posts { get; set; }
        public Command LoadPostsCommand { get; set; }
        public Command LoadMorePostsCommand { get; set; }

        public PostsViewModel()
        {

            Posts = new ObservableCollection<Post>();

            LoadPostsCommand = new Command(async () => await ExecuteLoadPostsCommand());
            LoadMorePostsCommand = new Command(async () => await ExecuteLoadMorePostsCommand());
        }


        async Task ExecuteLoadMorePostsCommand()
        {
            if (!IsLoadingMore)
            {
                Debug.WriteLine("Bashir: Loading More");
                IsLoadingMore = true;

                try
                {
                    if (paginationDTO.Page < totalAmountPages)
                    {
                        paginationDTO.Page++;
                        var paginatedResponse = await Repositories.PostRepository.GetPosts(paginationDTO);
                        foreach (var post in paginatedResponse.Response)
                            Posts.Add(post);
                    }
                    else
                    {
                        PostsFinished?.Invoke(this, EventArgs.Empty);
                        ItemTreshold = -1;
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    IsLoadingMore = false;
                }
            }
        }

        async Task ExecuteLoadPostsCommand()
        {
                IsBusy = true;

                try
                {
                    Posts.Clear();
                    paginationDTO.Page = 1;

                    var paginatedResponse = await Repositories.PostRepository.GetPosts(paginationDTO);
                    totalAmountPages = paginatedResponse.TotalAmountPages;
                    var posts = paginatedResponse.Response;
                    foreach (var post in posts)
                    {
                        Posts.Add(post);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    IsBusy = false;
                }
        }
    }
}
