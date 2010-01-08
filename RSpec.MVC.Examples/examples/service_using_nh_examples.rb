require 'spec_helper'

require '..\lib\NHibernate.dll'
include NHibernate

describe "Calling StoreService which calls NHibernate" do
   it "should return populated ViewModel" do
      service = Services::StoreService.new Impl::SessionImpl.new
      model = service.get_home_model
      model.should_not be_nil
   end
end