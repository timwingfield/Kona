def empty_database()
  #puts "We could do whatever... ;)"
end

Before do
  empty_database
end

at_exit do
  empty_database
end
