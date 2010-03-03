$: << '../Lib'
$: << 'support'
$: << '../Kona.Web/bin/'

require 'rubygems'
require 'stringio'

$_spec_spec = true # Prevents Kernel.exit in various places
require 'spec'

require 'Kona.dll'
include Kona
include Kona::Controllers
include Kona::App

require 'NHibernate.dll'
include NHibernate
include NHibernate::Cfg

require 'mocks.rb'
require 'mvc_extensions'

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