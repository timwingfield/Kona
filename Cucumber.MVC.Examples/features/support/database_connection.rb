$: << File.dirname(__FILE__)
require 'yaml'
require 'active_record'
require 'dir_extensions'
require 'faker'
require 'guid'

Dir.require_all File.dirname(__FILE__) + '/model'

  def open_connection
    db_config = YAML::load(File.open(File.join( File.dirname(__FILE__), 'database.yml')))
    ActiveRecord::Base.establish_connection db_config
  end
