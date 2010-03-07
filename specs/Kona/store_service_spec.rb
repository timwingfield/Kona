require '../spec_helper'
require 'nhibernate_helper'

describe Services::StoreService do
  let(:session) {NHibernate::create_session}
  let(:service) {Services::StoreService.new session}

  before(:all) do
    NHibernate::insert_single_category session
    model = service.get_home_model 0
  end

  it "should return constructed object" do
    model.should_not be_nil
  end

  it "should return all categories from database" do
    model.Categories.to_a.Count.should == 1
  end

  it "should populated returned category with Name"
  it "should populate return category with Description"
end