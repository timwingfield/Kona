def empty_database
  #puts "We could do whatever... ;)"
end

Before do
  open_connection
  empty_database
end

at_exit do
  empty_database
end