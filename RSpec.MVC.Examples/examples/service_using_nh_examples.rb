require 'spec_helper'

require 'NHibernate.dll'
include NHibernate
include NHibernate::Cfg
describe "NHibernate" do
  before do
    config = Configuration.new
    @cfg = config.configure(File.join(Dir.pwd, "nhibernate.config"))
  end

   it "can create session factory" do
     session_factory = @cfg.BuildSessionFactory()
     session_factory.should_not be_nil
   end

   it "can create session" do
     session_factory = @cfg.BuildSessionFactory()
     session = session_factory.open_session
     session.should_not be_nil
   end
   it "should be able to export the schema" do
     schema_export = System::Reflection::Assembly.LoadFrom('..\lib\NHibernate.dll'.ConvertToString).GetType('NHibernate.Tool.hbm2ddl.SchemaExport')
     export = System::Activator.CreateInstance schema_export, @cfg
     export_to_console = false
     run_against_database = true
     export.create export_to_console, run_against_database
   end
end

describe Services::StoreService do
  def create_schema(config)
    schema_export = System::Reflection::Assembly.LoadFrom('..\lib\NHibernate.dll'.ConvertToString).GetType('NHibernate.Tool.hbm2ddl.SchemaExport')
    export = System::Activator.CreateInstance schema_export, config
    export_to_console = false
    run_against_database = true
    export.create export_to_console, run_against_database
  end

  def create_config
    config = Configuration.new
    cfg = config.configure(File.join(Dir.pwd, "nhibernate.config"))
  end

  def create_session(cfg)
    session_factory = cfg.BuildSessionFactory()
    session = session_factory.open_session
    return session
  end

  before(:each) do
   cfg = create_config
   @session = create_session cfg
   create_schema cfg
  end

  it "should return populated home model" do
    service = Services::StoreService.new @session
    model = service.get_home_model 0
    model.should_not be_nil
  end
end