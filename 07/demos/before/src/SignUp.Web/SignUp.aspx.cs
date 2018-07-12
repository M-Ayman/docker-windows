using SignUp.Entities;
using SignUp.Messaging;
using SignUp.Messaging.Messages.Events;
using SignUp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SignUp.Web
{
    public partial class SignUp : Page
    {
        private static Dictionary<string, Country> _Countries;
        private static Dictionary<string, Role> _Roles;
        private static Dictionary<string, Interest> _Interests;

        public static void PreloadStaticDataCache()
        {
            _Countries = new Dictionary<string, Country>();
            _Roles = new Dictionary<string, Role>();
            _Interests = new Dictionary<string, Interest>();
            using (var context = new WebinarContext())
            {
                _Countries["-"] = context.Countries.Single(x => x.CountryCode == "-");
                foreach (var country in context.Countries.Where(x=>x.CountryCode != "-").OrderBy(x => x.CountryId))
                {
                    _Countries[country.CountryCode] = country;
                }

                _Roles["-"] = context.Roles.Single(x => x.RoleCode == "-");
                foreach (var role in context.Roles.Where(x => x.RoleCode != "-").OrderBy(x => x.RoleId))
                {
                    _Roles[role.RoleCode] = role;
                }
                
                foreach (var interest in context.Interests.Where(x => x.IsActive).OrderBy(x => x.InterestId))
                {
                    _Interests[interest.InterestCode] = interest;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateRoles();
                PopulateCountries();
                PopulateInterests();
            }
        }

        private void PopulateRoles()
        {
            ddlRole.Items.Clear();
            ddlRole.Items.AddRange(_Roles.Select(x => new ListItem(x.Value.RoleName, x.Key)).ToArray()); 
        }

        private void PopulateCountries()
        {
            ddlCountry.Items.Clear();
            ddlCountry.Items.AddRange(_Countries.Select(x => new ListItem(x.Value.CountryName, x.Key)).ToArray());
        }

        private void PopulateInterests()
        {
            chkListInterests.Items.Clear();
            chkListInterests.Items.AddRange(_Interests.Select(x => new ListItem(x.Value.InterestName, x.Key)).ToArray());
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            var viewer = new Viewer
            {
                EmailAddress = txtEmail.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text
            };

            viewer.Country = _Countries[ddlCountry.SelectedValue];
            viewer.Role = _Roles[ddlRole.SelectedValue];
            viewer.Interests = new List<Interest>();
            foreach (var selectedInterest in chkListInterests.Items.Cast<ListItem>().Where(x=> x.Selected))
            {
                viewer.Interests.Add(_Interests[selectedInterest.Value]);
            }
            
            var eventMessage = new ViewerSignedUpEvent
            {
                Viewer = viewer,
                SignedUpAt = DateTime.UtcNow
            };

            MessageQueue.Publish(eventMessage);

            Server.Transfer("ThankYou.aspx");
        }
    }
}