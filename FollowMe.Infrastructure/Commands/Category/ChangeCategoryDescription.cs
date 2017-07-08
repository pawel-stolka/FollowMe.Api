namespace FollowMe.Infrastructure.Commands.Category
{
    public class ChangeCategoryDescription : ICommand
    {
        public string CurrentDescription { get; set; }
        public string NewDescription { get; set; }
    }
}
