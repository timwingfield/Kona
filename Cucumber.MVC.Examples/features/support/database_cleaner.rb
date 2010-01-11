def empty_database
  date_of_last_restore = '01/01/2010'
  OrderItem.delete_all ["DateAdded > ?", date_of_last_restore]
  Order.delete_all ["CreatedOn > ?", date_of_last_restore]
end

Before do
  open_connection
  empty_database
end

at_exit do
  empty_database
end
