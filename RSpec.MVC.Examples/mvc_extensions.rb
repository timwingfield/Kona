require 'C:/Program Files/Microsoft ASP.NET/ASP.NET MVC 1.0/Assemblies/System.Web.Mvc.dll'

module MVCExtensions
   class System::Web::Mvc::ViewResult
      def view_model()
	self.view_data.model
      end
   end
end