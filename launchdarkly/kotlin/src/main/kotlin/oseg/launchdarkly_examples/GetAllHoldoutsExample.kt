package oseg.launchdarkly_examples

import com.launchdarkly.client.infrastructure.*
import com.launchdarkly.client.apis.*
import com.launchdarkly.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class GetAllHoldoutsExample
{
    fun getAllHoldouts()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        try
        {
            val response = HoldoutsBetaApi().getAllHoldouts(
                projectKey = "projectKey_string",
                environmentKey = "environmentKey_string",
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling HoldoutsBetaApi#getAllHoldouts")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling HoldoutsBetaApi#getAllHoldouts")
            e.printStackTrace()
        }
    }
}
