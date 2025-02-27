require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

personal_names_1 = NamsorClient::FirstLastNameIn.new
personal_names_1.id = "9a3283bd-4efb-4b7b-906c-e3f3c03ea6a4"
personal_names_1.first_name = "Keith"
personal_names_1.last_name = "Haring"

personal_names = [
    personal_names_1,
]

batch_first_last_name_in = NamsorClient::BatchFirstLastNameIn.new
batch_first_last_name_in.personal_names = personal_names

begin
    response = NamsorClient::PersonalApi.new.country_fn_ln_batch(
        {
            batch_first_last_name_in: batch_first_last_name_in,
        },
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling PersonalApi#country_fn_ln_batch: #{e}"
end
