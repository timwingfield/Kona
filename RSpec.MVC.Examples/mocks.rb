class StoreServiceMock 
  include Services::IStoreService

  def GetHomeModel(categoryId)
     model = ViewModels::ProductListViewModel.new
     model.SelectedCategory = Model::Category.new 'Test Category'
     model
  end
end