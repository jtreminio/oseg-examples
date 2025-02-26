require "json"
require "openapi_client"

OpenApiClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

begin
    OpenApiClient::UserApi.new.logout_user
rescue OpenApiClient::ApiError => e
    puts "Exception when calling UserApi#logout_user: #{e}"
end
