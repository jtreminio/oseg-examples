require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

personal_names_1 = NamsorClient::PersonalNameIn.new
personal_names_1.id = "0f472330-11a9-49ad-a0f5-bcac90a3f6bf"
personal_names_1.name = "Keith Haring"

personal_names = [
    personal_names_1,
]

batch_personal_name_in = NamsorClient::BatchPersonalNameIn.new
batch_personal_name_in.personal_names = personal_names

begin
    response = NamsorClient::PersonalApi.new.gender_full_batch(
        {
            batch_personal_name_in: batch_personal_name_in,
        },
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling PersonalApi#gender_full_batch: #{e}"
end
