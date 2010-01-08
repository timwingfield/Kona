require 'spec_helper'

describe "Creating MVC controllers" do
  it "should be able to call Index on ProductController" do 
     p = Kona::Controllers::ProductController.new nil
     p.should_not be_nil
  end
end