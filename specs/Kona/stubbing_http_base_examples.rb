require 'caricature'
include Caricature

describe "Stubbing HTTPContext etc objects in MVC" do
  it "can manually stub ApplicationPath on RequestBase" do
    home = HomeController.new nil
    result = home.locate_application_path Stubber.http_request2
    result.should == '~/test/2'
  end

  it "should stub ApplicationPath on RequestBase" do
    home = HomeController.new nil
    result = home.locate_application_path Stubber.http_request
    result.should == '~/test'
  end
end