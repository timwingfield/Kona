require 'spec_helper'

describe "Creating MVC controllers" do
  it "should be able to call Index on ProductController" do 
     p = ProductController.new nil
     p.should_not be_nil
  end

  it "can mock the IStoreSerivce" do 
     p = ProductController.new StoreServiceMock.new
     p.should_not be_nil
  end

  it "should return ViewModel from GetHomeModel" do 
     p = ProductController.new StoreServiceMock.new
     result = p.Index 0
     result.ViewData.should_not be_nil
  end

  it "can access Name of category on Model" do 
     p = ProductController.new StoreServiceMock.new
     result = p.Index 0
     result.view_model.selected_category.name.should == 'Test Category'
  end
end