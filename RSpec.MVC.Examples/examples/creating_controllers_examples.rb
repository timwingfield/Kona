require 'spec_helper'

describe "Creating MVC controllers" do
  it "should be able to call Index on ProductController" do 
     p = ProductController.new nil
     p.should_not be_nil
  end
end

  describe "Mocking Service manually" do
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

describe "Mocking Service using framework" do
  it "supports mocking IStoreService" do
     p = ProductController.new Stubber.get_store_service
     p.should_not be_nil
  end

  it "should return ViewModel from GetHomeModel" do
     p = ProductController.new Stubber.get_store_service
     result = p.Index 0
     result.ViewData.should_not be_nil
  end

  it "can access Name of category on Model" do
     p = ProductController.new Stubber.get_store_service
     result = p.Index 0
     result.view_model.selected_category.name.should == 'Test Category'
  end
end

describe "Mocking MVC framework" do
  it "can obtain ApplicationPath from HttpRequest" do
    h = HomeController.new nil
    path = h.locate_application_path Stubber.http_request
    path.should == '~/test'
  end
end