require 'spec_helper'
require 'nhibernate_helper'

describe Services::StoreService do
  let(:session) {NHibernate::create_session}
  let(:service) {Services::StoreService.new session}

  it "should return populated home model" do
    model = service.get_home_model 0
    model.should_not be_nil
  end

  it "should return all the categories in the database" do
    NHibernate::insert_category session
    model = service.get_home_model 0
    model.Categories.to_a.Count.should == 1
  end
end