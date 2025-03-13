require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

proper_nouns_1 = NamsorClient::NameGeoIn.new
proper_nouns_1.id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42"
proper_nouns_1.name = "Edi Gathegi"
proper_nouns_1.country_iso2 = "KE"

proper_nouns = [
    proper_nouns_1,
]

batch_name_geo_in = NamsorClient::BatchNameGeoIn.new
batch_name_geo_in.proper_nouns = proper_nouns

begin
    response = NamsorClient::GeneralApi.new.name_type_geo_batch(
        {
            batch_name_geo_in: batch_name_geo_in,
        },
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling GeneralApi#name_type_geo_batch: #{e}"
end
