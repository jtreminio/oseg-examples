package oseg.namsor_examples

import app.namsor.client.infrastructure.*
import app.namsor.client.apis.*
import app.namsor.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class PhoneCodeGeoBatchExample
{
    fun phoneCodeGeoBatch()
    {
        ApiClient.apiKey["X-API-KEY"] = "YOUR_API_KEY"

        val personalNamesWithPhoneNumbers1 = FirstLastNamePhoneNumberGeoIn(
            id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            firstName = "Teniola",
            lastName = "Apata",
            phoneNumber = "08186472651",
            countryIso2 = "NG",
            countryIso2Alt = "CI",
        )

        val personalNamesWithPhoneNumbers = arrayListOf<FirstLastNamePhoneNumberGeoIn>(
            personalNamesWithPhoneNumbers1,
        )

        val batchFirstLastNamePhoneNumberGeoIn = BatchFirstLastNamePhoneNumberGeoIn(
            personalNamesWithPhoneNumbers = personalNamesWithPhoneNumbers,
        )

        try
        {
            val response = SocialApi().phoneCodeGeoBatch(
                batchFirstLastNamePhoneNumberGeoIn = batchFirstLastNamePhoneNumberGeoIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling SocialApi#phoneCodeGeoBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling SocialApi#phoneCodeGeoBatch")
            e.printStackTrace()
        }
    }
}
