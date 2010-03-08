Given /^customer order for "([^\"]*)" and "([^\"]*)"$/ do |product1, product2|
  order = Order.find_or_create

  OrderItem.create_item(order, product1)
  OrderItem.create_item(order, product2)
end

Given /^customer order for "([^\"]*)"$/ do |product|
  order = Order.find_or_create

  OrderItem.create_item(order, product)
end

Given /^the featured product "([^\"]*)"$/ do |product_name|
    Product.find_or_create product_name
end

Given /^the following "([^\"]*)":$/ do |category, products|
  products.hashes.map do |p|
    p[:name]
  end
end

Given /^"([^\"]*)" in "([^\"]*)"/ do |product, category|
end