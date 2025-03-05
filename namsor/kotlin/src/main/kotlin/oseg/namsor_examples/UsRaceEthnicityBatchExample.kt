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

class UsRaceEthnicityBatchExample
{
    fun usRaceEthnicityBatch()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        val personalNames1 = FirstLastNameGeoIn(
            id = "85dd5f48-b9e1-4019-88ce-ccc7e56b763f",
            firstName = "Keith",
            lastName = "Haring",
            countryIso2 = "US",
        )

        val personalNames = arrayListOf<FirstLastNameGeoIn>(
            personalNames1,
        )

        val batchFirstLastNameGeoIn = BatchFirstLastNameGeoIn(
            personalNames = personalNames,
        )

        try
        {
            val response = PersonalApi().usRaceEthnicityBatch(
                batchFirstLastNameGeoIn = batchFirstLastNameGeoIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling PersonalApi#usRaceEthnicityBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling PersonalApi#usRaceEthnicityBatch")
            e.printStackTrace()
        }
    }
}
