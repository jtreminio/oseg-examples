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
class UsZipRaceEthnicityBatchExample
{
    fun usZipRaceEthnicityBatch()
    {
        ApiClient.apiKey["X-API-KEY"] = "YOUR_API_KEY"

        val personalNames1 = FirstLastNameGeoZippedIn(
            id = "728767f9-c5b2-4ed3-a071-828077f16552",
            firstName = "Keith",
            lastName = "Haring",
            countryIso2 = "US",
            zipCode = "10019",
        )

        val personalNames = arrayListOf<FirstLastNameGeoZippedIn>(
            personalNames1,
        )

        val batchFirstLastNameGeoZippedIn = BatchFirstLastNameGeoZippedIn(
            personalNames = personalNames,
        )

        try
        {
            val response = PersonalApi().usZipRaceEthnicityBatch(
                batchFirstLastNameGeoZippedIn = batchFirstLastNameGeoZippedIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling PersonalApi#usZipRaceEthnicityBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling PersonalApi#usZipRaceEthnicityBatch")
            e.printStackTrace()
        }
    }
}
