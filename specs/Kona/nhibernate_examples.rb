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
     export_to_console = true
     run_against_database = true
     export.create export_to_console, run_against_database
   end
end