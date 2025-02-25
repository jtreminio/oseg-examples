require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

layer_post = LaunchDarklyClient::LayerPost.new
layer_post.key = "checkout-flow"
layer_post.name = "Checkout Flow"
layer_post.description = nil

begin
    response = LaunchDarklyClient::LayersApi.new.create_layer(
        nil, # project_key
        layer_post,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling Layers#create_layer: #{e}"
end
