using System;
using System.Threading.Tasks;
using BaseProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebbApp.Template.UserCards
{
    //<user-card app-user="attribute"/>
    public class UserCardTagHelper:TagHelper
    {
        public AppUser AppUser { get; set; }

        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserCardTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            UserCardTemplate userCardTemplate;
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                userCardTemplate = new PrimeUserCardTemplate();

            }
            else
            {
                userCardTemplate = new DefaultUserCardTemplate();
            }

            userCardTemplate.SetUser(AppUser);
            output.Content.SetHtmlContent(userCardTemplate.Build());
        }

       
    }
}
