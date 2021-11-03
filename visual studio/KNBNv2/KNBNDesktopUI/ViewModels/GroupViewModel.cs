using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using KNBNDesktopUI.Library.Api;
using KNBNDesktopUI.Library.Models;

namespace KNBNDesktopUI.ViewModels
{
    public class GroupViewModel : Screen
    {
        private readonly StatusInfoViewModel _status;
        private readonly IWindowManager _window;
        private readonly IUserEndpoint _userEndpoint;
        private readonly IGroupEndpoint _groupEndpoint;



        public GroupViewModel(StatusInfoViewModel status, IWindowManager window, IUserEndpoint userEndpoint, IGroupEndpoint groupEndpoint)
        {
            _status = status;
            _window = window;
            _userEndpoint = userEndpoint;
            _groupEndpoint = groupEndpoint;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

            try
            {
                await LoadGroups();
            }
            catch (Exception ex)
            {
                dynamic settings = new ExpandoObject();
                settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                settings.ResizeMode = ResizeMode.NoResize;
                settings.Title = "System Error";

                switch (ex.Message)
                {
                    case "Unauthorized":
                        _status.UpdateMessage("Unauthorized Acces", "You shall not passed!");
                        await _window.ShowDialogAsync(_status, null, settings);
                        break;

                    case "Internal Server Error":
                        _status.UpdateMessage("Internal Server Error", "You shall not passed!");
                        await _window.ShowDialogAsync(_status, null, settings);
                        break;

                    default:
                        break;
                }
                /*
                if (ex.Message == "Unauthorized")
                {
                    _status.UpdateMessage("Unauthorized Acces", "You shall not passed!");
                    await _window.ShowDialogAsync(_status, null, settings);

                }
                */
            }
        }
        // Load all groups
        private async Task LoadGroups()
        {
            var groupList = await _groupEndpoint.GetAll();
            Groups = new BindingList<GroupModel>(groupList);
        }

        private async Task LoadUsers()
        {
            var userList = await _groupEndpoint.GetAllUsersToAdd(SelectedGroup.Id);
            var groupUserList = await _groupEndpoint.GetAllUsers(SelectedGroup.Id);
            Users = new BindingList<GroupUserModel>(userList);
            GroupUsers = new BindingList<GroupUserModel>(groupUserList);
            //Users.Clear();
            //AvailableUsers.Clear();
            /*
            foreach (var user in users)
            {
                
            }
            */
        }


        #region All Groups in database to select

        //private string SelectedGroupName;
        BindingList<GroupModel> _groups;
        public BindingList<GroupModel> Groups
        {
            get 
            { 
                return _groups; 
            }
            set
            {
                _groups = value;
                NotifyOfPropertyChange(() => Groups);
            }
        }
        
        // change the groupname to the selected group
        private GroupModel _selectedGroup;
        public GroupModel SelectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                _selectedGroup = value;
                SelectedGroupName = value.Name;

                Users.Clear();
                Users = new BindingList<GroupUserModel>();
                _ = LoadUsers();


                NotifyOfPropertyChange(() => SelectedGroup);

            }
        }

        #endregion

        public BindingList<GroupUserModel> _groupUsers { get; set; }

        private BindingList<GroupUserModel> _groupUser;

        public BindingList<GroupUserModel> GroupUsers
        {
            get 
            { 
                return _groupUser; 
            }
            set 
            { 
                _groupUser = value;
                NotifyOfPropertyChange(() => GroupUsers);
            }
        }


        private BindingList<GroupUserModel> _users = new BindingList<GroupUserModel>();

        public BindingList<GroupUserModel> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                NotifyOfPropertyChange(() => Users);
            }
        }


        #region All members of the selected group

        // change the text in textbox to the selected user

        private string _selectedGroupName;

        public string SelectedGroupName
        {
            get { return _selectedGroupName; }
            set
            {
                _selectedGroupName = value;
                NotifyOfPropertyChange(() => SelectedGroupName);
            }
        }

        #endregion
        /*

        //TODO Get all users in selected group



        //TODO Get all users not in selected group
        private BindingList<string> _availableUsers = new BindingList<string>();

        public BindingList<string> AvailableUsers
        {
            get { return _availableUsers; }
            set
            {
                _availableUsers = value;
                NotifyOfPropertyChange(() => AvailableUsers);
            }

        }




        #endregion
        */

        /* SQL CALL ON LOAD*/
    }
}
