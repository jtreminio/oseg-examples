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
class GenderFullGeoBatchExample
{
    fun genderFullGeoBatch()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        val personalNames1 = PersonalNameGeoIn(
            id = "3a2d203a-a6a4-42f9-acd1-1b5c56c7d39f",
            name = "Keith Haring",
            countryIso2 = "US",
        )

        val personalNames = arrayListOf<PersonalNameGeoIn>(
            personalNames1,
        )

        val batchPersonalNameGeoIn = BatchPersonalNameGeoIn(
            personalNames = personalNames,
        )

        try
        {
            val response = PersonalApi().genderFullGeoBatch(
                batchPersonalNameGeoIn = batchPersonalNameGeoIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling PersonalApi#genderFullGeoBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling PersonalApi#genderFullGeoBatch")
            e.printStackTrace()
        }
    }
}
