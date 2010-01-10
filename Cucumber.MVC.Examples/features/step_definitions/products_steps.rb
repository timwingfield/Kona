Given /^the featured product "([^\"]*)"$/ do |product|
end

Given /^the following "([^\"]*)":$/ do |category, products|
  products.hashes.map do |p|
    p[:name]
  end
end

Given /^"([^\"]*)" "([^\"]*)" product$/ do |product, category|
end

Then /^I should see "([^\"]*)" listed under "([^\"]*)"$/ do |product, area|
  within get_div_id(area) do |products|
    products.should contain(product)
  end
end

Then /^I should not see "([^\"]*)" listed under "([^\"]*)"$/ do |product, area|
  within get_div_id(area) do |products|
    products.should_not contain(product)
  end
end

Then /^I should see "([^\"]*)" listed$/ do |product|
  response.should contain(product)
end

def get_div_id(id)
  "#" + id.downcase.underscore
end