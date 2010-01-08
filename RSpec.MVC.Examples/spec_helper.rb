require 'rubygems'
require 'stringio'
 
$_spec_spec = true # Prevents Kernel.exit in various places
 
require 'spec'

require '../Kona.Web/bin/Kona.dll'
include Kona
include Kona::Controllers

require 'mocks.rb'

def jruby?
  ::RUBY_PLATFORM == 'java'
end