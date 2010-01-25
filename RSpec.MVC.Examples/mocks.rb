class StoreServiceMock 
  include Services::IStoreService

  def product_list_view_model()
    model = ViewModels::ProductListViewModel.new
    model.SelectedCategory = Model::Category.new 'Test Category'
    model
  end

  def GetHomeModel(categoryId)
    product_list_view_model
  end
end

require 'caricature'
include Caricature

require 'C:\Program Files\Reference Assemblies\Microsoft\Framework\v3.5\System.Web.Abstractions.dll'
class StubbedHttpRequestBase < System::Web::HttpRequestBase
  def ApplicationPath
    "~/test/2"
  end
end

class Stubber
  def self.product_list_view_model()
    model = ViewModels::ProductListViewModel.new
    model.SelectedCategory = Model::Category.new 'Test Category'
    model
  end

  def self.GetIStoreService()
    isolation = isolate Services::IStoreService
    isolation.when_receiving(:get_home_model).with(0).return(product_list_view_model()) #NOTE:  GetHomeModel and get_home_model are different!
    isolation
  end

  def self.http_request
    isolation = isolate System::Web::HttpRequestBase
    isolation.when_receiving(:application_path).return("~/test")
    isolation
  end

  def self.http_request2
    StubbedHttpRequestBase.new
  end
end
<<<<<<< HEAD
=======

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
>>>>>>> 4f053199054471974a4608683e0f678ac3a29cd2
