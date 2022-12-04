using Ninject;
using PlayStore.BLL.Modules;
using PlayStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.Infrastructure
{
    class ServiceLocator
    {
        IKernel kernel;
        public ServiceLocator()
        {
            kernel = new StandardKernel(new PlayStoreModule());
        }
        public RegistrationViewModel RegistrationViewModel => kernel.Get<RegistrationViewModel>();
        public CreateLoginAndPasswordViewModel CreateLoginAndPasswordViewModel => kernel.Get<CreateLoginAndPasswordViewModel>();
        public AuthorizationViewModel AuthorizationViewModel => kernel.Get<AuthorizationViewModel>();

        public AdministrationViewModel AdministrationViewModel => kernel.Get<AdministrationViewModel>();
        public AdministrationMenuViewModel AdministrationMenuViewModel => kernel.Get<AdministrationMenuViewModel>();

        public AddGameViewModel AddGameViewModel => kernel.Get<AddGameViewModel>();
        public AddSystemRequirementsViewModel AddSystemRequirementsViewModel => kernel.Get<AddSystemRequirementsViewModel>();

        public HistoryViewModel HistoryViewModel => kernel.Get<HistoryViewModel>();

        public UserMainViewModel UserMainViewModel => kernel.Get<UserMainViewModel>();
        public UserMenuViewModel UserMenuViewModel => kernel.Get<UserMenuViewModel>();
        public InfoByGameViewModel InfoByGameViewModel => kernel.Get<InfoByGameViewModel>();

        public CartViewModel CartViewModel => kernel.Get<CartViewModel>();
        public GameLibraryViewModel GameLibraryViewModel => kernel.Get<GameLibraryViewModel>();

        public AddCardViewModel AddCardViewModel => kernel.Get<AddCardViewModel>();

    }
}
