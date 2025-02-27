require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

proper_nouns_1 = NamsorClient::NameIn.new
proper_nouns_1.id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42"
proper_nouns_1.name = "Zippo"

proper_nouns = [
    proper_nouns_1,
]

batch_name_in = NamsorClient::BatchNameIn.new
batch_name_in.proper_nouns = proper_nouns

begin
    response = NamsorClient::GeneralApi.new.name_type_batch(
        {
            batch_name_in: batch_name_in,
        },
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling GeneralApi#name_type_batch: #{e}"
end
