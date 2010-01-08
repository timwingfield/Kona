class StoreServiceMock 
  include Kona::App::Services::IStoreService

  def GetHomeModel(categoryId)
     model = Kona::ViewModels::ProductListViewModel.new
     model.SelectedCategory = Kona::Model::Category.new 'Test Category'
     model
  end
end