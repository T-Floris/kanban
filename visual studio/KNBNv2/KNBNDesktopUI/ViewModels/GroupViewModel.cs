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
        
        //run when th viwe is lodet
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
        
        // Load all groups, and run on load
        private async Task LoadGroups()
        {
            var groupList = await _groupEndpoint.GetAll();
            Groups = new BindingList<GroupModel>(groupList);
        }

        // run when a group is selected
        private async Task LoadUsers()
        {
            var userInGroupList = await _groupEndpoint.GetAllUsers(SelectedGroup.Id, 1);
            var UserNotInGroupList = await _groupEndpoint.GetAllUsers(SelectedGroup.Id, 0);
            UsersInGroup = new BindingList<UserModel>(userInGroupList);
            Users = new BindingList<UserModel>(UserNotInGroupList);

        }


        #region Load in all Groups in database

        private BindingList<GroupModel> _groups;
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

        // get the selected group and set it's name (SelectedGroupName)
        // and load in all users in the group and all not in the group
        private GroupModel _selectedGroup;
        public GroupModel SelectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                _selectedGroup = value;
                SelectedGroupName = value.Name;

                _ = LoadUsers();

                NotifyOfPropertyChange(() => SelectedGroup);
            }
        }

        #region get name of the selected group

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


        #endregion

        #region Load in all users in selected group
        private BindingList<UserModel> _usersInGroup { get; set; }

        public BindingList<UserModel> UsersInGroup
        {
            get 
            { 
                return _usersInGroup; 
            }
            set 
            {
                _usersInGroup = value;
                NotifyOfPropertyChange(() => UsersInGroup);
            }
        }

        #endregion

        #region Load in all users not in selecte group
        private BindingList<UserModel> _users = new BindingList<UserModel>();

        public BindingList<UserModel> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                NotifyOfPropertyChange(() => Users);
            }
        }
        #endregion



        public async Task AddUserToGroup()
        {
            try
            {
                var users = Users;

                foreach (var user in users)
                {
                    await _groupEndpoint.AddUserToGroup(SelectedGroup.Id, user.Id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

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
