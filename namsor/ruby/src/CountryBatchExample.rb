require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

personal_names_1 = NamsorClient::PersonalNameIn.new
personal_names_1.id = "9a3283bd-4efb-4b7b-906c-e3f3c03ea6a4"
personal_names_1.name = "Keith Haring"

personal_names = [
    personal_names_1,
]

batch_personal_name_in = NamsorClient::BatchPersonalNameIn.new
batch_personal_name_in.personal_names = personal_names

begin
    response = NamsorClient::PersonalApi.new.country_batch(
        {
            batch_personal_name_in: batch_personal_name_in,
        },
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling PersonalApi#country_batch: #{e}"
end
