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
class UsRaceEthnicityFullBatchExample
{
    fun usRaceEthnicityFullBatch()
    {
        ApiClient.apiKey["X-API-KEY"] = "YOUR_API_KEY"

        val personalNames1 = PersonalNameGeoIn(
            id = "85dd5f48-b9e1-4019-88ce-ccc7e56b763f",
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
            val response = PersonalApi().usRaceEthnicityFullBatch(
                batchPersonalNameGeoIn = batchPersonalNameGeoIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling PersonalApi#usRaceEthnicityFullBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling PersonalApi#usRaceEthnicityFullBatch")
            e.printStackTrace()
        }
    }
}
