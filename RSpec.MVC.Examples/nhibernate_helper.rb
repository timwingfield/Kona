module NHibernate
  def create_schema(config)
    schema_export = System::Reflection::Assembly.LoadFrom('..\lib\NHibernate.dll'.ConvertToString).GetType('NHibernate.Tool.hbm2ddl.SchemaExport')
    export = System::Activator.CreateInstance schema_export, config
    export_to_console = false
    run_against_database = true
    export.create export_to_console, run_against_database
  end

  def create_config
    config = Configuration.new
    config.configure(File.join(Dir.pwd, "nhibernate.config"))
  end

  def create_session()
    cfg = create_config
    session_factory = cfg.BuildSessionFactory()
    session = session_factory.open_session
    create_schema cfg
    return session
  end

  def insert_category(session)
    category = Model::Category.new
    category.Name = 'Test'
    category.Description = 'Test Category'
    session.save category
  end
end