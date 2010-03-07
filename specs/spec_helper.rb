$: << '../Lib'
$: << 'specs/Support'
$: << '../Kona.Web/bin/'
$: << 'C:/Program Files/Reference Assemblies/Microsoft/Framework/v3.5/'

require 'rubygems'
require 'stringio'

$_spec_spec = true # Prevents Kernel.exit in various places
require 'spec'

require 'System.Web.Abstractions.dll'
require 'Kona.dll'
include Kona
include Kona::Controllers
include Kona::App

require 'NHibernate.dll'
include NHibernate
include NHibernate::Cfg

require 'mvc_extensions'

require 'caricature'
include Caricature

def jruby?
  ::RUBY_PLATFORM == 'java'
end

module Spec::Example  
  
  module ExampleGroupMethods  
    include MVCExtensions
  end  
  
  module ExampleMethods  
    # place your example helper methods (instance methods) like do_action here  
  end  
  
end