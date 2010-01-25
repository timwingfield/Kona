require 'C:/Program Files/Microsoft ASP.NET/ASP.NET MVC 1.0/Assemblies/System.Web.Mvc.dll'

module MVCExtensions
 class System::Web::Mvc::ViewResult
<<<<<<< HEAD
  def view_model()
    self.view_data.model
  end
=======
    def view_model()
      self.view_data.model
    end
>>>>>>> 4f053199054471974a4608683e0f678ac3a29cd2
 end
end