Given /^customer order for "([^\"]*)" and "([^\"]*)"$/ do |product1, product2|
  order = Order.find_or_create

  OrderItem.create_item(order, product1)
  OrderItem.create_item(order, product2)
end

Given /^customer order for "([^\"]*)"$/ do |product|
  order = Order.find_or_create

  OrderItem.create_item(order, product)
end