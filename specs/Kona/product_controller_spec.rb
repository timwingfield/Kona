require '../spec_helper'

describe ProductController, "Product homepage requested" do
  context "with empty Category" do
    before(:each) do
      store_service = nil
      category_id = nil

      controller = ProductController.new store_service
      @result = controller.Index category_id
    end

    it "should redirect to main landing page" do
      @result.route_values["controller"].should == "Index"
	  @result.route_values["home"].should == "Home"
    end
  end

  context "with valid Category" do
      def product_list(selected)
        model = ViewModels::ProductListViewModel.new
        model.SelectedCategory = Model::Category.new selected
        model
      end

      before(:each) do
        valid_category_id = 1
        view_model = product_list('Test Category')
        
        service = isolate Services::IStoreService
        service.when_receiving(:get_home_model).with(valid_category_id).return(view_model)
        controller = ProductController.new service
        @result = controller.Index categoryID
      end

      it "returns a view model" do
         @result.view_model.should_not == nil
      end

      it "should return name of selected category" do
        @result.view_model.selected_category.name.should == 'Test Category'
      end
    end

    context "with invalid categoryID" do
      it "should redirect to error page"
    end
end

