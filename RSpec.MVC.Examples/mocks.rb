class StoreServiceMock 
  include Services::IStoreService

  def GetHomeModel(categoryId)
     model = ViewModels::ProductListViewModel.new
     model.SelectedCategory = Model::Category.new 'Test Category'
     model
  end
end

require 'C:\Program Files\Reference Assemblies\Microsoft\Framework\v3.5\System.Web.Abstractions.dll'
require 'caricature'
include Caricature
class Stubber
  def self.product_list_model
    model = ViewModels::ProductListViewModel.new
    model.SelectedCategory = Model::Category.new 'Test Category'
    model
  end

  def self.store_service()
    isolation = isolate(Services::IStoreService)
    isolation.when_receiving(:get_home_model).with(0).return(product_list_model)
    isolation
  end

  def self.http_request()
    isolation = isolate(System::Web::HttpRequestBase)
    isolation.when_receiving(:application_path).return("~/test")
    isolation
  end
end


class ManualHttpRequest < System::Web::HttpRequestBase
  def ApplicationPath
    return "~/test"
  end
end