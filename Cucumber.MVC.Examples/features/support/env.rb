$: << File.dirname(__FILE__)
require "spec/expectations"
require "webrat"
require 'cucumber/cli/options'
require 'string_extensions.rb'
require 'database_cleaner.rb'

class CucumberWorld < Webrat::MechanizeAdapter
end

World do
  CucumberWorld.new
end

def url
  "http://localhost:5764"
end