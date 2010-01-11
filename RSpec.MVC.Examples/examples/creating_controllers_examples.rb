require 'spec_helper'

describe "Creating MVC controllers" do
  it "should be able to call Index on ProductController" do 
     p = ProductController.new nil
     p.should_not be_nil
  end
end

describe "Mocking IStoreService" do
  let(:p) {ProductController.new Stubber.GetIStoreService}
  let(:category_id) {0}

  it "can mock the IStoreSerivce" do
     p.should_not be_nil
  end

  it "should return ViewData from GetHomeModel" do
     p.Index(category_id).ViewData.should_not be_nil
  end

  it "should return ViewModel from GetHomeModel" do
     p.Index(category_id).ViewData.Model.should_not be_nil
  end

  it "can access Name of category on Model via view_model" do
     p.Index(category_id).view_model.SelectedCategory.name.should == 'Test Category'
  end
end